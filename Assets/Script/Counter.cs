using System;

public class Counter
{
    private const int StartValue = 0;
    private const int StepValue = 1;

    public int Value { get; private set; }

    public int Step { get; private set; }

    public Counter()
    {
        Value = StartValue;
        Step = StepValue; 
    }

    public void RaiseValue()
    {
        if (Value >= int.MaxValue)
        {
            throw new ArgumentException(); 
        }

        Value += Step; 
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
