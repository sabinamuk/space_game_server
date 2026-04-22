namespace SpaceBattle.Lib;

public class Vector
{
    private readonly int[] _coordinates;

    public Vector(params int[] coordinates)
    {
        _coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
    }

    public int this[int index] => _coordinates[index];

    public int Size => _coordinates.Length;

    public static Vector operator +(Vector a, Vector b)
    {
        if (a.Size != b.Size)
            throw new ArgumentException("Vectors must have same dimension.");

        int[] result = new int[a.Size];

        for (int i = 0; i < a.Size; i++)
        {
            result[i] = a[i] + b[i];
        }

        return new Vector(result);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Vector other || Size != other.Size)
            return false;

        for (int i = 0; i < Size; i++)
        {
            if (this[i] != other[i])
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_coordinates.Length, string.Join(",", _coordinates));
    }

    public static bool operator ==(Vector a, Vector b)
    {
        return Equals(a, b);
    }

    public static bool operator !=(Vector a, Vector b)
    {
        return !Equals(a, b);
    }
}
