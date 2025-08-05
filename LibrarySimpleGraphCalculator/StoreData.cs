
namespace LibrarySimpleGraphCalculator
{
    public class StoreData
    {
        public StoreData() { }
        public string Name { get; set; } //sin(x),...

        public string CurrentUnit { get; set; }

        public double XValue {  get; set; }

        public double FunctionValue { get; set; }

        public int MinXValue { get; set; }
            
        public int MaxXValue { get; set; }

        public double IncrementRad {  get; set; }
    }
}
