﻿using Dunet;

namespace AdventOfCode.Common.Challenge;

[Union]
public partial record ChallengeResult
{
    public partial record Success(object Result)
    {
        public T GetResult<T>() => (T)Result;
    }
    public partial record NotCompleted;
    public partial record Error(Exception Exception);
}
