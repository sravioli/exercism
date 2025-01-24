using System;
using System.Threading;

public struct ComplexNumber(double real, double imaginary)
{
    private double _real = real;
    private double _imag = imaginary;

    public double Real() => _real;

    public double Imaginary() => _imag;

    public ComplexNumber Mul(ComplexNumber other) =>
        new(
            _real * other.Real() - _imag * other.Imaginary(),
            _imag * other.Real() + _real * other.Imaginary()
        );

    public ComplexNumber Mul(int other) => new(_real * other, _imag * other);

    public ComplexNumber Add(ComplexNumber other) =>
        new(_real + other.Real(), _imag + other.Imaginary());

    public ComplexNumber Add(int other) => new(_real + other, _imag);

    public ComplexNumber Sub(ComplexNumber other) =>
        new(_real - other.Real(), _imag - other.Imaginary());

    public ComplexNumber Div(ComplexNumber other)
    {
        var pow = Math.Pow(other.Real(), 2) + Math.Pow(other.Imaginary(), 2);
        return new ComplexNumber(
            (_real * other.Real() + _imag * other.Imaginary()) / pow,
            (_imag * other.Real() - _real * other.Imaginary()) / pow
        );
    }

    public ComplexNumber Div(int other) => new(_real / other, _imag / other);

    public double Abs() => Math.Sqrt(_real * _real + _imag * _imag);

    public ComplexNumber Conjugate() => new(_real, -_imag);

    public ComplexNumber Exp() =>
        new(Math.Exp(_real) * Math.Cos(_imag), Math.Exp(_real) * Math.Sin(_imag));
}
