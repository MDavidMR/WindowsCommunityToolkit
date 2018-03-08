# **AE Animation**

| Key     | Type| Value|
| --- | ---  | --- |
| ddd| enum |3D flag    |
| ip| float|  In Point (frame at which object enters)|
| op| float    |  Out Point (frame at which object exits) |
| w| float |  Width    |
| h    | float   |  Height   |
| v| string   |  BodyMovin Version|
| layers| array |Layer objects of these types -> shape, solid, comp, image, text, null|
| assets| array |Source objects of these types -> images, precomps |
| chars| array |Source objects of chars for text layers |
********************
# **Transform**

| Key     | Type| Value|
| --- | ---  | --- |
| a| object|Anchor Point    |
| p| object| Position|
| px| object    |  Position X |
| py| object |  Position Y    |
| s | object   |  Scale   |
| r| object   |  Rotation|
********************

# **Layer**

| Key     | Type| Value|
| --- | ---  | --- |
| ty | enum  | Layer Type  |
| ks | object | Transform properties   |
| ao | enum | Auto-Orient AE field   |
| bm | enum | Blend Mode  |
| ddd | enum | 3D flag |
| ind | int | Index for render order |
| cl | string | Class (used for html) |
| ln | string | Layer Name (used for html) |
| ip | float | In Point |
| op | float | Out Point |
| st | float | Start Time |
| nm | enum | AE Layer Name used for expressions |
| hasMask | enum | Indicates whether layer has masks |
| maskProperties | array | List of Mask objects |
| ef | array | List of Effects |
| sr | float | Stretch for Time Stretching??  |
| parent | int | Index (ind) of Layer Parent |

## PreComp Layer

ty = 0

| Key | Type| Value|
| --- | ---  | --- |
| refId | string | ID pointing to PreComposition Source defined in Assets array |
| tm | float | PreComp's Time Remapping?? |

## Solid Layer

ty = 1

| Key | Type| Value|
| --- | ---  | --- |
| sc | string | Solid Color |
| sw | float | Solid Width |
| sh | float | Solid Height |

## Image Layer

ty = 2

| Key | Type| Value|
| --- | ---  | --- |
| refId | string | ID pointing to Image Source defined in Assets array |

## Null Layer

ty = 3

## Shape Layer

ty = 4

| Key | Type| Value|
| --- | ---  | --- |
| it | array | Items of Shape types -> Shape, Rect, Ellipse, Star, Fill, Gradient Fill, Gradient Stroke, Stroke, Merge, Trim, Group, Rounded Corners|


## Text Layer

ty = 5

See [the Bodymovin Text Layer page](https://github.com/bodymovin/bodymovin/blob/master/docs/json/layers/text.json)
********************

# **Shapes**

| Key     | Type| Value|
| --- | ---  | --- |
| mn | string  | AE Match Name (used for expressions)  |
| nm | string | AE Name (used for expressions)   |
| ty | string | Type   |

## Ellipse

ty = "el"

| Key     | Type| Value|
| --- | ---  | --- |
| d | float??  | Direction in which shape is drawn (sense)  |
| p | object | Position |
| s | object | Size   |

## Fill

ty = "fl"

| Key     | Type| Value|
| --- | ---  | --- |
| o | object  | Fill Opacity  |
| c | object | Fill Color |

## Gradient Fill

ty = "gf"

| Key     | Type| Value|
| --- | ---  | --- |
| o | object  | Fill Opacity  |
| s | object | Gradient Start Point |
| e | object | Gradient End Point |
| t | enum | Gradient Type -> Linear (1), Radial (2) |
| h | object | Gradient Highlight Length (for Radial) |
| a | object | Gradient Highlight Angle (for Radial) |
| g | object?? | Gradient Colors |


## Gradient Stroke

ty = "gs"

| Key     | Type| Value|
| --- | ---  | --- |
| o | object  | Fill Opacity  |
| s | object | Gradient Start Point |
| e | object | Gradient End Point |
| t | enum | Gradient Type -> Linear (1), Radial (2) |
| h | object | Gradient Highlight Length (for Radial) |
| a | object | Gradient Highlight Angle (for Radial) |
| g | object?? | Gradient Colors |
| w | object | Stroke Width |
| lc | enum | Stroke Line Cap |
| lj | enum | Stroke Line Join |
| ml | float | Stroke Miter Limit (only if lj = Miter) |

## Group

ty = "gr"

| Key     | Type| Value|
| --- | ---  | --- |
| np | int  | Number of Properties (used for expressions)  |
| it | array | Items in group -> sh, rc, el, sr, fl, gf, gs, st, mm, tm, gr, rd, tr |

## Merge

ty = "mm" [NOT SUPPORTED]

## Rect

ty= "rc"

| Key     | Type| Value|
| --- | ---  | --- |
| d | float??  | Direction in which shape is drawn (sense)  |
| p | object | Position |
| s | object | Size |
| r | object | Rounded Corners |

## Rounded Corners

ty = "rd"

| Key     | Type| Value|
| --- | ---  | --- |
| r | object | Rounded Corner Radius |

## Shape

ty = "sh"

| Key     | Type| Value|
| --- | ---  | --- |
| d | float??  | Direction in which shape is drawn (sense)  |
| ks | object | Vertices |

ks can be of these types:
* [shape properties](https://github.com/bodymovin/bodymovin/blob/master/docs/json/properties/shape.json)
* [shape keyframe properties](https://github.com/bodymovin/bodymovin/blob/master/docs/json/properties/shapeKeyframed.json)

## Star

ty = "sr"

| Key     | Type| Value|
| --- | ---  | --- |
| d | float??  | Direction in which shape is drawn (sense)  |
| p | object | Position |
| ir | object | OuterRadius |
| is | object | Outer Roundness |
| pt | object | Number of Points |
| sy | enum | Star Type -> Star (1), Polygon (2) |

## Stroke

ty = "st"

| Key     | Type| Value|
| --- | ---  | --- |
| o | object  | Stroke Opacity  |
| c | object  | Stroke Color  |
| w | object | Stroke Width |
| lc | enum | Stroke Line Cap |
| lj | enum | Stroke Line Join |
| ml | float | Stroke Miter Limit (only if lj = Miter) |

## Trim 

ty = "tm"

| Key     | Type| Value|
| --- | ---  | --- |
| s | object  | Trim Start  |
| e | object  | Trim End  |
| o | object | Trim Offset |

## Transform

ty = "tr"


| Key     | Type| Value|
| --- | ---  | --- |
| a| object|Anchor Point    |
| s | object   |  Scale   |
| r| object   |  Rotation|
| sk |  object  | Skew  |
| sa |  object  | Skew Axis |

*********************************
