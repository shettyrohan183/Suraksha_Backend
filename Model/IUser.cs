namespace Final_youtube.Model
{
    public interface IUser
    {
        List<User> GetUsers();

        User GetUserById(int empId);
        void AddUser(User use);
        void DeleteUser(int id);

        void UpdateUser(User emp);
    }
}
