namespace GenialSchedule.Application
{
    /// <summary>
    /// This class is used as a marker to identify the assembly during dependency injection setup.
    ///
    /// It does not contain any logic or behavior; its sole purpose is to provide a reference point
    /// for scanning and registering services using frameworks like Scrutor or other DI helpers.
    ///
    /// Usage:
    /// - Use `typeof(AssemblyMarking)` in your DI configuration to point to this assembly.
    /// - Example: services.Scan(scan => scan.FromAssemblyOf<AssemblyMarking>());
    /// </summary>
    public record AssemblyMarking;
}