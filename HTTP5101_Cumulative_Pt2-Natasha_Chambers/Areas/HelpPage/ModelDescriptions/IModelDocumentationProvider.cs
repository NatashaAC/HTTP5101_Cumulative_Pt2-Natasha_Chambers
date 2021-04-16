using System;
using System.Reflection;

namespace HTTP5101_Cumulative_Pt2_Natasha_Chambers.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}