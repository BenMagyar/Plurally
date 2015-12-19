# Plurally - A .NET Pluralizer

Plurally is a mono-compatabile replacement to the entity
framework pluralization services. Provides methods to test if
a word is plural or singular, and convert between plural and
singular words.

## Methods

### Plurally([optional] CultureInfo)
The constructor accepts an optional `CultureInfo` type during initialization. If
no `CultureInfo` is supplied, Plurally will default to `CultureInfo.CurrentCulture`.

### IsPlural(string word)
Determines if the specified word is plural.
```
new Plurally().IsPlural("Pluralizers")
>> True
```

### IsSingular(string word)
Determines if the specified word is singular.
```
new Plurally().IsSingular("Pluralizer")
>> True
```

### Pluralize(string word)
Pluralize the specified word. If a word is already plural it will be returned.
Case will be (attempted) maintained.
```
new Plurally().Pluralize("Pluralizer")
>> "Pluralizers"
```

### Singularize(string word)
Singularize the specified word. If a word is already singular it will be returned.
Case will be (attempted) maintained.
```
new Plurally().Pluralize("Pluralizers")
>> "Pluralizer"
```

## Language Support

Current support is limited to English alone. To add additional languages please
open a pull request with a new locale.
