using System;
using System.Collections.Generic;

namespace OnionVb02.Application.CustomMappers.Interfaces;

public interface ICustomMapper<TSource, TDestination>
{
    TDestination Map(TSource source);
    List<TDestination> MapList(List<TSource> sources);
}

