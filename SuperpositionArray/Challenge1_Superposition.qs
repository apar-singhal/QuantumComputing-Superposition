namespace Quantum.SuperpositionArray
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

	/// # Summary
    /// Given a Qubit and a Boolean this array sets the Qubit to One if Boolean is True.
    ///
    /// # Input
    /// ## Qubit
    /// Qubit whose value to set.
	/// ## Bool
	/// If True, Qubit wil be set to One.
	operation Set(qubit:Qubit, val:Bool):()
	{
		body
		{
			if(val)
			{
				X(qubit);
			}
		}
	}

	/// # Summary
    /// Given two boolean arrays returns a qubit register in the corresponding superposition state.
    ///
    /// # Input
    /// ## Bool[]
    /// The type of the left array.
	/// ## Bool[]
	/// The type of the right array.
    /// # Qubit[]
    /// The qubit register to put in the superposition state corresponding to the given 2 boolean arrays.
	///
	/// # Precondition
	/// Length of both the arrays must be same
    operation DoSuperPos(arr1 : Bool[], arr2 : Bool[], register : Qubit[]) : ()
    {
        body
        {
			mutable controller = -1;
				
			
			for(idx in 0..Length(arr1)-1)
			{
				Set(register[idx], arr1[idx]);

				if(arr1[idx] != arr2[idx])
				{
					if(controller == -1)
					{
						H(register[idx]);
					}
					else
					{
						if(arr1[controller] == true)
						{
							X(register[idx]);
						}

						CNOT(register[controller], register[idx]);
					}
					set controller = idx;
				}
			}
        }
    }

	/// # Summary
    /// Measures all the qubits int the given qubit register and returns the result.
    ///
    /// # Input
    /// ## Qubit[]
    /// The Qubit register whose value to measure.
	///
    /// # Output
    /// ## Result[]
    /// The Result we get after measuring the given Qubit register.
	operation MeasureAll(register : Qubit[]) : (Result[])
	{
		body
		{
			mutable result = new Result[Length(register)];
			for(idx in 0..Length(result)-1)
			{
				set result[idx] = M(register[idx]);
			}

			return result;
		}
	}

	/// # Summary
    /// The EntryPoint which takes 2 boolean arrays and returns the result.
    ///
    /// # Input
    /// ## Bool[]
    /// The type of the left array.
	/// ## Bool[]
	/// The type of the right array.
	///
    /// # Output
    /// ## Result[]
    /// The Result we get after measuring the superposition of given arrays.
	operation DoSuperPosTest(A:Bool[], B:Bool[]) : (Result[])
	{
		body
		{
			mutable result = new Result[Length(A)];

			using(register = Qubit[Length(A)])
			{
				DoSuperPos(A, B, register);
				set result = MeasureAll(register);
				ResetAll(register);
			}

			return (result);
		}
	}
}
