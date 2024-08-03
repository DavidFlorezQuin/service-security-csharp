namespace Entity.Model.Security
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime created_at { get; set; }

        public DateTime created_by { get; set; }


        public DateTime updated_at { get; set; }

        public DateTime updated_by { get; set; }

        public DateTime deleted_at { get; set; }
        public DateTime deleted_by { get; set; }

        public bool state { get; set; }
    }
}
