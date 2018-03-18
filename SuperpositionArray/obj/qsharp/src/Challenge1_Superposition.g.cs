#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.SuperpositionArray", "Set (qubit : Qubit, val : Bool) : ()", new string[] { }, "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs", 399L, 15L, 2L)]
[assembly: OperationDeclaration("Quantum.SuperpositionArray", "DoSuperPos (arr1 : Bool[], arr2 : Bool[], register : Qubit[]) : ()", new string[] { }, "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs", 998L, 39L, 5L)]
[assembly: OperationDeclaration("Quantum.SuperpositionArray", "MeasureAll (register : Qubit[]) : Result[]", new string[] { }, "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs", 1842L, 81L, 2L)]
[assembly: OperationDeclaration("Quantum.SuperpositionArray", "DoSuperPosTest (A : Bool[], B : Bool[]) : Result[]", new string[] { }, "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs", 2440L, 107L, 2L)]
#line hidden
namespace Quantum.SuperpositionArray
{
    public class Set : Operation<(Qubit,Boolean), QVoid>
    {
        public Set(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(Qubit,Boolean), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.SuperpositionArray.Set", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (qubit,val) = _args;
#line 18 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    if (val)
                    {
#line 20 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                        MicrosoftQuantumPrimitiveX.Apply(qubit);
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.SuperpositionArray.Set", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit qubit, Boolean val)
        {
            return __m__.Run<Set, (Qubit,Boolean), QVoid>((qubit, val));
        }
    }

    public class DoSuperPos : Operation<(QArray<Boolean>,QArray<Boolean>,QArray<Qubit>), QVoid>
    {
        public DoSuperPos(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Quantum.SuperpositionArray.Set), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get
            {
                return this.Factory.Get<IUnitary<(Qubit,Qubit)>, Microsoft.Quantum.Primitive.CNOT>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<(Qubit,Boolean), QVoid> Set
        {
            get
            {
                return this.Factory.Get<ICallable<(Qubit,Boolean), QVoid>, Quantum.SuperpositionArray.Set>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(QArray<Boolean>,QArray<Boolean>,QArray<Qubit>), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.SuperpositionArray.DoSuperPos", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (arr1,arr2,register) = _args;
#line 42 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    var controller = -(1L);
#line 45 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    foreach (var idx in new Range(0L, (arr1.Count - 1L)))
                    {
#line 47 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                        Set.Apply((register[idx], arr1[idx]));
#line 49 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                        if ((arr1[idx] != arr2[idx]))
                        {
#line 51 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                            if ((controller == -(1L)))
                            {
#line 53 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                                MicrosoftQuantumPrimitiveH.Apply(register[idx]);
                            }
                            else
                            {
#line 57 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                                if ((arr1[controller] == true))
                                {
#line 59 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                                    MicrosoftQuantumPrimitiveX.Apply(register[idx]);
                                }

#line 62 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                                MicrosoftQuantumPrimitiveCNOT.Apply((register[controller], register[idx]));
                            }

#line 64 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                            controller = idx;
                        }
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.SuperpositionArray.DoSuperPos", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, QArray<Boolean> arr1, QArray<Boolean> arr2, QArray<Qubit> register)
        {
            return __m__.Run<DoSuperPos, (QArray<Boolean>,QArray<Boolean>,QArray<Qubit>), QVoid>((arr1, arr2, register));
        }
    }

    public class MeasureAll : Operation<QArray<Qubit>, QArray<Result>>
    {
        public MeasureAll(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.M) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        public override Func<QArray<Qubit>, QArray<Result>> Body
        {
            get => (register) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.SuperpositionArray.MeasureAll", OperationFunctor.Body, register);
                var __result__ = default(QArray<Result>);
                try
                {
#line 84 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    var result = new QArray<Result>(register.Count);
#line 85 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    foreach (var idx in new Range(0L, (result.Count - 1L)))
                    {
#line 87 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                        result[idx] = M.Apply<Result>(register[idx]);
                    }

#line hidden
                    __result__ = result;
#line 90 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.SuperpositionArray.MeasureAll", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QArray<Result>> Run(IOperationFactory __m__, QArray<Qubit> register)
        {
            return __m__.Run<MeasureAll, QArray<Qubit>, QArray<Result>>(register);
        }
    }

    public class DoSuperPosTest : Operation<(QArray<Boolean>,QArray<Boolean>), QArray<Result>>
    {
        public DoSuperPosTest(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Quantum.SuperpositionArray.DoSuperPos), typeof(Quantum.SuperpositionArray.MeasureAll), typeof(Microsoft.Quantum.Primitive.Release), typeof(Microsoft.Quantum.Primitive.ResetAll) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected ICallable<(QArray<Boolean>,QArray<Boolean>,QArray<Qubit>), QVoid> DoSuperPos
        {
            get
            {
                return this.Factory.Get<ICallable<(QArray<Boolean>,QArray<Boolean>,QArray<Qubit>), QVoid>, Quantum.SuperpositionArray.DoSuperPos>();
            }
        }

        protected ICallable<QArray<Qubit>, QArray<Result>> MeasureAll
        {
            get
            {
                return this.Factory.Get<ICallable<QArray<Qubit>, QArray<Result>>, Quantum.SuperpositionArray.MeasureAll>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<QArray<Qubit>, QVoid> ResetAll
        {
            get
            {
                return this.Factory.Get<ICallable<QArray<Qubit>, QVoid>, Microsoft.Quantum.Primitive.ResetAll>();
            }
        }

        public override Func<(QArray<Boolean>,QArray<Boolean>), QArray<Result>> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.SuperpositionArray.DoSuperPosTest", OperationFunctor.Body, _args);
                var __result__ = default(QArray<Result>);
                try
                {
                    var (A,B) = _args;
#line 110 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    var result = new QArray<Result>(A.Count);
#line 112 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    var register = Allocate.Apply(A.Count);
#line 114 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    DoSuperPos.Apply((A, B, register));
#line 115 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    result = MeasureAll.Apply<QArray<Result>>(register);
#line 116 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    ResetAll.Apply(register);
#line hidden
                    Release.Apply(register);
#line hidden
                    __result__ = result;
#line 119 "F:\\QuantumComputing\\Workspace\\SuperpositionArray\\SuperpositionArray\\Challenge1_Superposition.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.SuperpositionArray.DoSuperPosTest", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QArray<Result>> Run(IOperationFactory __m__, QArray<Boolean> A, QArray<Boolean> B)
        {
            return __m__.Run<DoSuperPosTest, (QArray<Boolean>,QArray<Boolean>), QArray<Result>>((A, B));
        }
    }
}