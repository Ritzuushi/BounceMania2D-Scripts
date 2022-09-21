using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.FSM
{
    public enum TestEnum
    {
        One,
        Two,
        Three
    }

    [CreateAssetMenu]
    public class TestFSM : FiniteStateMachine<TestEnum>
    {

    }
}
