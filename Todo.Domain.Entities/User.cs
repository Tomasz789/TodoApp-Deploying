using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using Todo.Domain.Entities.IdGenerator;
using TodoApp.DataVerifier;

namespace Todo.Domain.Entities
{
    /// <summary>
    /// Class represents an user entity.
    /// </summary>
    public class IdentityUser : EntityId
    {
        public IdentityUser(Guid id, string username, string email, string password)
        {
            this.Id = id;
            this.SetUserName(username);
            this.SetUserEmail(email);
            this.SetPassword(password);

            this.Created = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        protected IdentityUser()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        [MaxLength(25)]
        public string UserName { get; private set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; private set; }

        [Required]
        [MinLength(8)]

        public string Password { get; private set; }

        public DateTime Created { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<TodoList> TodoLists { get; set; }


        public bool SetUserName(string userName)
        {
            try
            {
                Verifier.Verify(userName, EntityDataType.USERNAME);
            }
            catch (Exception)
            {
                return false;
            }

            this.UserName = userName;
            return true;
        }

        public bool SetUserEmail(string email)
        {
            try
            {
                Verifier.Verify(email, EntityDataType.EMAIL);
            }
            catch (Exception)
            {
                return false;
            }

            this.Email = email;

            return true;
        }

        /// <summary>
        /// Method allows set user password.
        /// Password has to contatins at least 8 characters, one number, one letter and special character.
        /// </summary>
        /// <param name="password">String representation of password.</param>
        /// <exception cref="ArgumentException">When the password is invalid.</exception>
        public bool SetPassword(string password)
        {
            try
            {
                Verifier.Verify(password, EntityDataType.PASSWORD);
            }
            catch (Exception)
            {
                return false;
            }


            this.Password = password;
            return true;
        }

    }
}
