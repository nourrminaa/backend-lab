import type { FilterType } from "../types";
import "./FilterBar.css";

interface FilterBarProps {
  currentFilter: FilterType;
  onChangeFilter: (filter: FilterType) => void;
}

const FILTERS: { label: string; value: FilterType }[] = [
  { label: "All", value: "all" },
  { label: "Incomplete", value: "incomplete" },
  { label: "Completed", value: "completed" },
];

export function FilterBar({ currentFilter, onChangeFilter }: FilterBarProps) {
  return (
    <div className="filter-bar">
      {FILTERS.map((filter) => (
        <button
          key={filter.value}
          className={
            currentFilter === filter.value
              ? "filter-button filter-button-active"
              : "filter-button"
          }
          onClick={() => onChangeFilter(filter.value)}
        >
          {filter.label}
        </button>
      ))}
    </div>
  );
}
