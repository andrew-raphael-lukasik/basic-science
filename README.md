# Structures and syntax that helps with basic scientific calculations in [Unity](http://unity.com/)

```csharp
Using SI;

// conversion:
ly alfa_centauri_dist = (parsec) 1.34;
deg radian_in_degrees = (rad) 1.0;
s sidereal_day = (h) 23.9344696;
m3ps2 jovian_μ = (kg) 1.898e27;

// deduce unit from calculation:
mps speed = (m) 100 / (s) 3.1;
J heat = (W) 500 * (min) 60;
```
