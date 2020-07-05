# Structures and syntax to help with basic scientific calculations in [Unity](http://unity.com/)

```csharp
using BasicScience;

// conversion:
ly alfa_centauri_dist = (pc) 1.34;
deg radian_in_degrees = (rad) 1.0;
s sidereal_day = (h) 23.9344696;
m3ps2 jovian_μ = (kg) 1.898e27;// [m^3/s^2]

// units deduced from calculation:
var speed = (m) 100 / (s) 3.1;// [m/s]
var heat = (W) 500 * (min) 60;// [J]
var tesla_accel = (mps)(kmph) 96.56 / (s) 2.3;// [m/s^2]
```

# Instalation
Add this line in `manifest.json` / `dependencies`:
```
"dependencies": {
    "com.andrewraphaellukasik.basicscience": "https://github.com/andrew-raphael-lukasik/basic-science.git#upm",
}
```

Or via `Package Manager` / `Add package from git URL`:
```
https://github.com/andrew-raphael-lukasik/basic-science.git#upm
```
