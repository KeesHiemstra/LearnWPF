using System.Collections.ObjectModel;

namespace MasterDetails1.Model
{
  class SolutionList
  {

    private ObservableCollection<Solution> solutions;

    public ObservableCollection<Solution> Solutions
    {
      get => solutions;
    }

    public SolutionList()
    {
      solutions = new ObservableCollection<Solution>();

      Solution solution = new Solution() { Name = "Banking", Folder = "C:\\Dev\\Banking" };
      solution.Projects.Add(new Project() { Name = "Banking" });
      solution.Projects.Add(new Project() { Name = "Develop MissedTalliesView" });
      Solutions.Add(solution);

      solution = new Solution() { Name = "Tools", Folder = "C:\\Dev\\Tools" };
      solution.Projects.Add(new Project() { Name = "CopyLogonBackgroundPicture" });
      solution.Projects.Add(new Project() { Name = "MedicineStock" });
      Solutions.Add(solution);

    }

  }
}
