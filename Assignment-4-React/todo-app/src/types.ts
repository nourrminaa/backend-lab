// A "type" or "interface" in TypeScript describes the shape of a value.
// It doesn't exist in plain JavaScript - it's checked by the TypeScript
// compiler while you're writing code, then it disappears completely
// when the code is compiled down to JavaScript for the browser.

// This is the shape of ONE task in our app.
export interface Task {
  id: string;       // unique id, we generate it with crypto.randomUUID()
  text: string;      // what the task says, e.g. "Finish Codexion mindmap"
  completed: boolean; // has it been checked off?
}

// The filter can only ever be one of these three exact strings.
// This is called a "union type" - TypeScript will yell at us (in our
// editor, before we even run the code) if we try to assign anything
// else to a variable of type FilterType.
export type FilterType = "all" | "completed" | "incomplete";
