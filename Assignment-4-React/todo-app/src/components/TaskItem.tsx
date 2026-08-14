import { useState } from "react";
import type { Task } from "../types";
import "./TaskItem.css";

interface TaskItemProps {
  task: Task;
  onToggle: (id: string) => void;
  onDelete: (id: string) => void;
  onEdit: (id: string, newText: string) => void;
}

export function TaskItem({ task, onToggle, onDelete, onEdit }: TaskItemProps) {
  const [isEditing, setIsEditing] = useState(false);
  const [draftText, setDraftText] = useState(task.text);

  function startEditing() {
    setDraftText(task.text);
    setIsEditing(true);
  }

  function cancelEditing() {
    setIsEditing(false);
  }

  function saveEditing() {
    const trimmed = draftText.trim();
    if (trimmed === "") return;
    onEdit(task.id, trimmed);
    setIsEditing(false);
  }

  function handleDraftChange(e: React.ChangeEvent<HTMLInputElement>) {
    setDraftText(e.target.value);
  }

  function handleKeyDown(e: React.KeyboardEvent<HTMLInputElement>) {
    if (e.key === "Enter") saveEditing();
    if (e.key === "Escape") cancelEditing();
  }

  return (
    <li className="task-item">
      {isEditing ? (
        <>
          <input
            type="text"
            className="task-item-edit-input"
            value={draftText}
            onChange={handleDraftChange}
            onKeyDown={handleKeyDown}
            autoFocus
          />
          <button
            className="task-item-btn task-item-save"
            onClick={saveEditing}
          >
            Save
          </button>
          <button className="task-item-btn" onClick={cancelEditing}>
            Cancel
          </button>
        </>
      ) : (
        <>
          <input
            type="checkbox"
            className="task-item-checkbox"
            checked={task.completed}
            onChange={() => onToggle(task.id)}
          />
          <span
            className={
              task.completed
                ? "task-item-text task-item-text-done"
                : "task-item-text"
            }
          >
            {task.text}
          </span>
          <button className="task-item-btn" onClick={startEditing}>
            Edit
          </button>
          <button
            className="task-item-btn task-item-delete"
            onClick={() => onDelete(task.id)}
          >
            Delete
          </button>
        </>
      )}
    </li>
  );
}
