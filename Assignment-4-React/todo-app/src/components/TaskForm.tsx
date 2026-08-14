import { useState } from "react";
import "./TaskForm.css";

interface TaskFormProps {
  onAddTask: (text: string) => void;
}

export function TaskForm({ onAddTask }: TaskFormProps) {
  const [text, setText] = useState("");

  function handleChange(e: React.ChangeEvent<HTMLInputElement>) {
    setText(e.target.value);
  }

  function handleAddClick() {
    const trimmed = text.trim();
    if (trimmed === "") return;

    onAddTask(trimmed);
    setText("");
  }

  function handleKeyDown(e: React.KeyboardEvent<HTMLInputElement>) {
    if (e.key === "Enter") {
      handleAddClick();
    }
  }

  return (
    <div className="task-form">
      <input
        type="text"
        className="task-form-input"
        placeholder="Add a new task..."
        value={text}
        onChange={handleChange}
        onKeyDown={handleKeyDown}
      />
      <button className="task-form-button" onClick={handleAddClick}>
        Add
      </button>
    </div>
  );
}
