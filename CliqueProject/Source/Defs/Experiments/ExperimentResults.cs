namespace CliqueProject.Source.Defs.Experiments;

class ExperimentResult(int size, float density, string type, double time, double maxCliqueSize)
{
    public int GraphSize { get; } = size;
    public float Density { get; } = density;
    public string RepresentationType { get; } = type;
    public double ExecutionTimeMs { get; } = time;
    public double MaxCliqueSize { get; } = maxCliqueSize;
}