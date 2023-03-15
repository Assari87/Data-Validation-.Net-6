namespace ConsoleApp1
{
    public class TestServices
    {
        private List<DataModel> tableInfos = new List<DataModel>();
        private List<DataModel> invalidRecord = new List<DataModel>();

        public bool IsEmpty => tableInfos.Count == 0;
        public string TableInfoStatus => tableInfos.Count == 0 ? "List is empty" : string.Join("\n", tableInfos.Select((d, index) => $"{index}: {d}"));
        public string InvalidStatus => invalidRecord.Count == 0 ? "List is empty" : string.Join("\n", invalidRecord.Select((d, index) => $"{index}: {d}"));

        public void LoadDefault()
        {
            tableInfos =
            new List<DataModel> {
              new DataModel(10,false,14,true,70),
              new DataModel(5,true,10,true,60),
              new DataModel(20,true,null,false,100),
              new DataModel(null,false,5,false,50),
              new DataModel(14,false,20,false,90)
            };

            Validate();
        }

        public void AddData(DataModel tableModel)
        {
            if (tableModel != null)
            {
                if (tableModel.Start != null &&
                    tableModel.End != null &&
                    tableModel.End <= tableModel.Start)
                {
                    Utility.WriteLineError("End is greater than Start!");
                    return;
                }

                tableInfos.Add(tableModel);
                Validate();
            }
            else
            {
                Utility.WriteLineError("Data is wrong!");
            }
        }

        public void DeleteItem(int index)
        {
            tableInfos.RemoveAt(index);

            Validate();
        }

        public void Validate()
        {
            tableInfos = tableInfos.OrderBy(a => a.Start ?? -1).ToList();

            var result =
              tableInfos.Where((item, index) =>
              {
                  if (index == 0 && item.Start != null)
                      return true;

                  if (tableInfos.Count - 1 == index)
                      return item.End != null;

                  var nextItem = tableInfos[index + 1];

                  return item.RealEnd + 1 != nextItem.RealStart;
              });

            invalidRecord = result.ToList();

            if (invalidRecord.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Utility.WriteLineError(InvalidStatus);
            }
            else
            {
                Utility.WriteLineSuccess("\nAll records are Valid");
            }
        }

        public int? CalculateResult(int input)
        {
            var data = tableInfos.SingleOrDefault(p => p.IsInclusiveNumber(input));
            return data?.Result;
        }

    }
}
