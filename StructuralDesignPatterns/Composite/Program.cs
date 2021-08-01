using System;
using System.Collections.Generic;

ExecutiveEmployee GeneralManager = new (EnumJobRole.GeneralManager, "Michael", 10000m);

ExecutiveEmployee TeamLeader = new (EnumJobRole.TeamLeader,"Jim", 8000m);
GeneralManager.Add(TeamLeader);
TeamLeader.Add(new IndividualEmployee(EnumJobRole.Analyst, "Pam", 7000));
TeamLeader.Add(new IndividualEmployee(EnumJobRole.Developer, "Creed", 7000));
TeamLeader.Add(new IndividualEmployee(EnumJobRole.Developer, "Meredith", 7000));
TeamLeader.Add(new IndividualEmployee(EnumJobRole.Developer, "Toby", 7000));
TeamLeader.Add(new IndividualEmployee(EnumJobRole.Tester, "Andy", 7000));

ExecutiveEmployee HeadOfDevelopment = new (EnumJobRole.HeadOfDevelopment, "Gabe", 9000m);
GeneralManager.Add(HeadOfDevelopment);

ExecutiveEmployee FrontEndLeader = new (EnumJobRole.FrontEndLeader, "Angela", 8000m);
HeadOfDevelopment.Add(FrontEndLeader);
FrontEndLeader.Add(new IndividualEmployee(EnumJobRole.Designer, "Oscar", 7000));
FrontEndLeader.Add(new IndividualEmployee(EnumJobRole.Developer, "Kevin", 7000));

ExecutiveEmployee BackEndLeader = new (EnumJobRole.BackEndLeader, "Dwight", 8000m);
HeadOfDevelopment.Add(BackEndLeader);
BackEndLeader.Add(new IndividualEmployee(EnumJobRole.Developer, "Stanley", 7000));
BackEndLeader.Add(new IndividualEmployee(EnumJobRole.Developer, "Kelly", 7000));
BackEndLeader.Add(new IndividualEmployee(EnumJobRole.Tester, "Ryan", 7000));

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine($"Salary of team {GeneralManager.GetTeamSalary()}");
GeneralManager.Chart(1);
Console.ReadLine();


//Console.WriteLine(FrontEndLeader.GetTeamSalary());
//Console.WriteLine(HeadOfDevelopment.GetTeamSalary());
//Console.WriteLine(TeamLeader.GetTeamSalary());
//Console.WriteLine(GeneralManager.GetTeamSalary());



public enum EnumJobRole
{
    GeneralManager,
    TeamLeader,
    BackEndLeader,
    FrontEndLeader,
    HeadOfDevelopment,
    Analyst,
    Developer,
    Tester,
    Designer,

}

public abstract class Employee
{
    protected string _name;
    protected decimal _salary;
    protected EnumJobRole _role;
    public Employee(EnumJobRole role,string name,decimal salary)
    {
        _role = role;
        _name = name;
        _salary = salary;
    }
    public virtual void Add(Employee e)
    {
        throw new NotImplementedException();
    }
    public virtual void Remove(Employee e)
    {
        throw new NotImplementedException();
    }
    public decimal GetSalary() 
    {
        return _salary;
    }
    public virtual decimal GetTeamSalary()
    {
        return GetSalary();
    }
    public abstract void Chart(int indent);
}

public class IndividualEmployee : Employee
{
    public IndividualEmployee(EnumJobRole role, string name, decimal salary) : base(role, name, salary)
    {

    }

    public override void Chart(int indent)
    {
        Console.WriteLine($"{new String('-', indent)}{_role.ToString()} {_name}");
    }
    // We didn't override the Add, Remove, GetTeamSalary methods because IndividualEmploye doesn't have any subordinate
}

public class ExecutiveEmployee : Employee
{
    public List<Employee> subordinates = new List<Employee>();
    public ExecutiveEmployee(EnumJobRole role,string name, decimal salary) : base(role,name, salary)
    {

    }
    public override void Add(Employee e)
    {
        subordinates.Add(e);
    }
    public override void Remove(Employee e)
    {
        subordinates.Remove(e);
    }
    public override decimal GetTeamSalary()
    {
        decimal totalSalary = 0m;
        foreach (Employee e in subordinates)
        {
            totalSalary += e.GetTeamSalary();
        }
        return totalSalary+_salary;
    }
    public override void Chart(int indent)
    {
        Console.WriteLine($"{new String('-', indent)}+{_role.ToString()} {_name}");

        foreach (Employee e in subordinates)
        {
            e.Chart(indent + 2);
        }
    }
}