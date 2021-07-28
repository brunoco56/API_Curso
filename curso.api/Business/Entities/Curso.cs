namespace curso.api.Business.Entities
{
    public class Curso
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public int CodigoUsuario { get; set; }


        //saber quantos cursos o usuario tem
        public virtual Usuario Usuario { get; set; }
    }
}
