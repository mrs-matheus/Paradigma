namespace ParadigmaArvore.Entities
{
    public class Tree
    {
        public int RootValue { get; set; }
        public List<Branch> LeftBranches { get; set; }
        public List<Branch> RightBranches { get; set; }
    }
}
