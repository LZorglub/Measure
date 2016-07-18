# Measure

This library provides units management in different measure system (International System, CGS, Imperial system and US). 
The guidelines of SI can be found [here](http://www.nist.gov/pml/pubs/sp330/index.cfm)

# NUGET
The easiest way to install is by using [NuGet](https://www.nuget.org/packages/Afk.Measure/).

## Concept
The library expose **Unit** and **Quantity<T>**. Units belongs to a dimension (7 physical and 1 currency dimension), the quantity represents one value with associated unit. Operations like addition, substraction, comparaison are allowed only if unit of quantity belongs the same dimension.
Conversion between quantities are done using the unit base converter. Each unit have a converter to go the unit base (SI unit), conversion from unit to another is built on merge of each unit converter.

## Syntax
#### Units
The space character is not allowed as unit separator because it can be part of existing unit like fluid ounce "fl oz". 
The . or (char)183 are the unit multiplicator separator and the / is the unit divisor multiplicator.
To obtain an unit you can use predefined units or try to parse a string :
```C#
        Unit unit = Unit.Parse("ms"); // Represents the milliseconds
        bool boolean = Unit.TryParse("skg", out unit); // Returns false
        boolean = Unit.TryParse("s.kg", out unit); // Returns true, seconds * gram
        unit = (Unit)"Wh"; // Represents the WattHour
        unit = SIPrefixe.Kilo * SI.METER; // Represents the km
        unit = (Unit)"m-2.kg/s"; // Represents m-2.kg.s-1
```  
#### Quantity
Quantity is a generic class, the type can be anything until you need mathematical operations.
Instanciations are done using constructor/static methods or by implicit conversion.
```C#
                Quantity<double> dd = 20; // Quantity unitless
                Acceleration<double> acc = 15; // Acceleration m.s-2
                Quantity<double> kg = 10 * SI.GRAM; // Gram 10kg
                Length<int> meter = 2; // Length 2m
                Quantity<double> meterAcc = acc * meter; // Quantity multiplication
                var tempK = Quantity.From<double>(SI.KELVIN, 293.15); // Quantity From
                var tempC = new Quantity<double>(20, "°C"); // Quantity constructor
                bool compare = tempK == tempC; // True
``` 

## Prefix
Prefix are only authorize on SI unit. To avoid any confusion usage of multiple prefix is not allowed, for sample 10 MV.ms is not allowed, 10 kV is preferable. The prefix is put on numerator.
This consideration do not apply on the kilogram which is the base unit from Gram, for sample 1 mol/kg will be preferable to 1 mmol/g.
The *Quantity* class manage product of unit with prefix and will choose the best prefix to use.

## Currency
The library manage physical units and currency unit. The base currency of the library is the euro.
The currency unit convertion depends on exchange rate and can not be set at compile time. To manage the exchange rate you need to instanciate a *CurrencyContext* and specify the exchange rate between your currency and the euro. The *CurrencyContext* use TLS approach (ThreadLocalStorage) so is different for each threads.
```C#
                using (var context = new CurrencyContext())
                {
                    context.AddOrReplaceConverter("$", 0.87745);
                    context.AddOrReplaceConverter("¥", 0.00785);

                    var dollar = 1 * Unit.Parse("$");
                    Console.WriteLine("{0} Dollar to Yen : {1}", dollar.Value, dollar.ConvertTo("¥").Value);
                }
```
