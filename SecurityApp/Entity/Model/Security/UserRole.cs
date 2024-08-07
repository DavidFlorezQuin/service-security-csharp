namespace Entity.Model.Security
{
    public class UserRole : ABaseModel
    {
        public int RoleId { get; set; }
        public Role Role { get; set; } = new Role();    
        public int UserId { get; set; }
        public User User { get; set; } = new User();

    }
}
