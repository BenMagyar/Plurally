# Plurally - A .NET Pluralizer
[![Build status](https://ci.appveyor.com/api/projects/status/j556mxsqrim1fxd9?svg=true)](https://ci.appveyor.com/project/BenMagyar/plurally)

Plurally is a mono-compatabile replacement to the entity
framework pluralization services. Provides methods to test if
a word is plural or singular, and convert between plural and
singular words.

## Methods

### Pluralizer([optional] CultureInfo)
The constructor accepts an optional `CultureInfo` type during initialization. If
no `CultureInfo` is supplied, Plurally will default to `CultureInfo.CurrentCulture`.

### IsPlural(string word)
Determines if the specified word is plural.
```
new Pluralizer().IsPlural("Pluralizers")
>> True
```

### IsSingular(string word)
Determines if the specified word is singular.
```
new Pluralizer().IsSingular("Pluralizer")
>> True
```

### Pluralize(string word)
Pluralize the specified word. If a word is already plural it will be returned.
Case will be (attempted) maintained.
```
new Pluralizer().Pluralize("Pluralizer")
>> "Pluralizers"
```

### Singularize(string word)
Singularize the specified word. If a word is already singular it will be returned.
Case will be (attempted) maintained.
```
new Pluralizer().Pluralize("Pluralizers")
>> "Pluralizer"
```

## Language Support

Current support is limited to English alone. To add additional languages please
open a pull request with a new locale.
