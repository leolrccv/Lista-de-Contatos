namespace Lista {
    class Pessoa {
        public string Nome { get; set; }
        public Telefone[] telefone { get; set; }
        public Pessoa Proximo { get; set; }

        public override string ToString() {
            string fones = "";
            foreach (Telefone t in telefone)
                fones += t;
            return "\n>>DADOS DO CONTATO<<<\nNome:" + Nome + fones;
        }
    }
}
