namespace ConsoleApp1
{
    public class DataModel
    {
        public int? Start;
        public bool InclusiveStart;

        public int? End;
        public bool InclusiveEnd;

        public int Result;

        public DataModel() { }
        public DataModel(int? start, bool inclusiveStart, int? end, bool inclusiveEnd, int result)
        {
            Start = start;
            InclusiveStart = inclusiveStart;
            End = end;
            InclusiveEnd = inclusiveEnd;
            Result = result;
        }

        public int? RealStart => this.Start == null ? this.Start : (this.InclusiveStart ? this.Start : this.Start + 1);
        public int? RealEnd => this.End == null ? this.End : (this.InclusiveEnd ? this.End : this.End - 1);

        public bool IsInclusiveNumber(int number)
        {
            return (this.Start == null || this.RealStart <= number) && (this.End == null || this.RealEnd >= number);
        }

        public override string ToString()
        {
            return $"{this.Start?.ToString() ?? "Inf"} {(this.InclusiveStart ? "<=" : "<")} C1 {(this.InclusiveEnd ? "<=" : "<")} {(this.End?.ToString() ?? "Inf")} ===> {Result}";
        }
    }

}
