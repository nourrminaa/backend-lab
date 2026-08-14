import { useEffect, useState } from "react";
import type { Task, FilterType } from "./types";
import { TaskForm } from "./components/TaskForm";
import { FilterBar } from "./components/FilterBar";
import { TaskList } from "./components/TaskList";
import "./App.css";

const STORAGE_KEY = "task-tracker-tasks";

function App() {
  const [filter, setFilter] = useState<FilterType>("all");

  const [tasks, setTasks] = useState<Task[]>(() => {
    const saved = localStorage.getItem(STORAGE_KEY);
    return saved ? JSON.parse(saved) : [];
  });

  useEffect(() => {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(tasks));
  }, [tasks]);

  function addTask(text: string) {
    const newTask: Task = {
      id: crypto.randomUUID(),
      text,
      completed: false,
    };
    setTasks([...tasks, newTask]);
  }

  function toggleTask(id: string) {
    setTasks(
      tasks.map((task) =>
        task.id === id ? { ...task, completed: !task.completed } : task,
      ),
    );
  }

  function deleteTask(id: string) {
    setTasks(tasks.filter((task) => task.id !== id));
  }

  function editTask(id: string, newText: string) {
    setTasks(
      tasks.map((task) => (task.id === id ? { ...task, text: newText } : task)),
    );
  }

  const filteredTasks = tasks.filter((task) => {
    if (filter === "completed") return task.completed;
    if (filter === "incomplete") return !task.completed;
    return true;
  });

  const completedCount = tasks.filter((task) => task.completed).length;
  const progress =
    tasks.length === 0 ? 0 : (completedCount / tasks.length) * 100;

  return (
    <main className="app-card">
      <header className="app-header">
        <div className="app-header-top">
          <h1>Task Tracker</h1>
          <span className="app-count">
            {completedCount}/{tasks.length} done
          </span>
        </div>
        <div className="app-progress-track">
          <div
            className="app-progress-fill"
            style={{ width: `${progress}%` }}
          />
        </div>
      </header>

      <TaskForm onAddTask={addTask} />
      <FilterBar currentFilter={filter} onChangeFilter={setFilter} />
      <TaskList
        tasks={filteredTasks}
        onToggle={toggleTask}
        onDelete={deleteTask}
        onEdit={editTask}
      />
    </main>
  );
}

export default App;
