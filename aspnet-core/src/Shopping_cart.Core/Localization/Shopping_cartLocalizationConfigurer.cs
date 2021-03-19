using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Shopping_cart.Localization
{
    public static class Shopping_cartLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(Shopping_cartConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(Shopping_cartLocalizationConfigurer).GetAssembly(),
                        "Shopping_cart.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
