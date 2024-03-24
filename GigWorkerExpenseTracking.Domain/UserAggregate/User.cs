using GigWorkerExpenseTracking.Domain.Commons;
using GigWorkerExpenseTracking.Domain.UserAggregate.ValueObjects;
using System;

namespace GigWorkerExpenseTracking.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        //public bool IsEmailVerified { get; private set; }
        //public string EmailVerificationToken { get; private set; }

        private User(): base(default!)
        {

        }
        private User(UserId id = null!, string firstName = null!, string lastName = null!, string username = null!, string email = null!, byte[] passwordHash = null!, byte[] passwordSalt = null!) : base(id)
        {
           
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            //IsEmailVerified = false;
            //EmailVerificationToken = null!;
        }

        public static User CreateNewUser(string firstName, string lastName, string username, string email, byte[] passwordHash, byte[] passwordSalt)
        {
 
            var id = UserId.CreateID();

            return new User(id, firstName, lastName, username, email, passwordHash, passwordSalt);
        }

        public void VerifyEmail(string verificationToken)
        {

           // IsEmailVerified = true;
            //EmailVerificationToken = null!;
        }

        public void ChangePassword(byte[] newPasswordHash, byte[] newPasswordSalt)
        {

            PasswordHash = newPasswordHash;
            PasswordSalt = newPasswordSalt;
        }
    }
}
