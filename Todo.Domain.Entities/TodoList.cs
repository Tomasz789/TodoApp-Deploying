using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Todo.Domain.Entities.MainEntity;
using TodoApp.DataVerifier;

namespace Todo.Domain.Entities
{
    public class TodoList : Main
    {
        private readonly IList<TodoTask> todoTasks = new List<TodoTask>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }

        public virtual IEnumerable<TodoTask> Tasks => todoTasks;

        /// <summary>
        /// Add a new task to to-do list.
        /// </summary>
        /// <param name="todoTask">Task to do.</param>
        /// <returns>Number of items in the task list.</returns>
        /// <exception cref="ArgumentNullException">If the task is null.</exception>
        public void AddTaskToList(TodoTask todoTask)
        {
            if (todoTask == null)
            {
                throw new ArgumentNullException(nameof(todoTask));
            }

            todoTasks.Add(todoTask);
        }

    }
}
