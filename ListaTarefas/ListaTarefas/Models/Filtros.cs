namespace ListaTarefas.Models
{
    public class Filtros
    {
        public Filtros(string filtroString) {
            //recebe os filtros selecionados e separa eles em um array
            FiltroString = filtroString ?? "9-todos-9"; //caso o filtro venha vazio, coloca como "todos"
            string[] filtros = FiltroString.Split("-");
            CategoriaId = int.Parse(filtros[0]);
            Vencimento = filtros[1];
            StatusId = int.Parse(filtros[2]);


        }

        public string FiltroString { get; set; }
        public int CategoriaId { get; set; }
        public int StatusId { get; set; }
        public string Vencimento { get; set; }


        public bool TemCategoria => CategoriaId != 9;
        public bool TemVencimento => Vencimento.ToLower() != "todos";
        public bool TemStatus => StatusId != 9;



        public static Dictionary<string, string> VencimentoValoresFiltro =>
             new Dictionary<string, string> {
                 {"passado","Passado" },
                 {"hoje","Hoje" },
                 {"futuro","Futuro" }
             };

        public bool EPassado => Vencimento.ToLower() == "passado";
        public bool EPresente => Vencimento.ToLower() == "presente";
        public bool EFuturo => Vencimento.ToLower() == "futuro";


    }
}
