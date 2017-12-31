module Fable.Recharts

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop

module Props =

    type [<StringEnum>] Layout =
        | Horizontal
        | Vertical

    type [<StringEnum>] StackOffset =
        | Expand
        | Wiggle
        | Silhouette
        | Sign
        | [<CompiledName("none")>] NoStackOffset

    type [<StringEnum>] BaseValue =
        | DataMin
        | DataMax
        | Auto

    type [<StringEnum>] Interpolation =
        | Basis
        | BasisClosed
        | BasisOpen
        | Linear
        | LinearClosed
        | Natural
        | MonotoneX
        | MonotoneY
        | Monotone
        | Step
        | StepBefore
        | StepAfter
        //| Function

    type [<StringEnum>] Legend =
        | Line
        | Square
        | Rect
        | Circle
        | Cross
        | Diamond
        | Star
        | Triangle
        | Wye
        | [<CompiledName("none")>] NoLegend

    type [<StringEnum>] Easing =
        | Ease
        | [<CompiledName("ease-in")>] EaseIn
        | [<CompiledName("ease-out")>] EaseOut
        | [<CompiledName("ease-in-out")>] EaseInOut
        | Linear

    type [<Pojo>] CoordinatePoint =
        { x: float
          y: float
          value: float }

    type [<Pojo>] Margin =
        { top: float
          bottom: float
          right: float
          left: float }

    type [<RequireQualifiedAccess>] Chart =
        /// If any two categorical charts(LineChart, AreaChart, BarChart, ComposedChart) have the same syncId, these two charts can sync the position tooltip, and the startIndex, endIndex of Brush.
        | SyncId of string
        | Layout of Layout
        | Width of float
        | Height of float
        | Data of System.Array
        | Margin of Margin

        /// BarChart: The gap between two bar categories, which can be a percent value or a fixed value.
        | BarCategoryGap of obj
        /// BarChart: The gap between two bars, which can be a percent value or a fixed value.
        | BarGap of obj
        /// BarChart: The width or height of each bar. If the barSize is not specified, the size of the bar will be calculated by the barCategoryGap, barGap and the quantity of bar groups.
        | BarSize of float
        /// BarChart: The maximum width of all the bars in a horizontal BarChart, or maximum height in a vertical BarChart.
        | MaxBarSize of float
        /// BarChart: The type of offset function used to generate the lower and upper values in the series array. The four types are built-in offsets in d3-shape.
        | StackOffset of StackOffset

        /// AreaChart: The base value of are.
        | BaseValue of U2<float, BaseValue>

        /// ComposedChart: If false set, stacked items will be rendered left to right. If true set, stacked items will be rendered right to left. (Render direction affects SVG layering, not x position.)
        | ReverseStackOrder of bool

        /// RadarChart: [Percentage (e.g. "50%") | Number] The x-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of width.
        | Cx of obj
        /// RadarChart: [Percentage (e.g. "50%") | Number] The y-coordinate of center. If set a percentage, the final value is obtained by multiplying the percentage of height.
        | Cy of obj
        /// RadarChart: The angle of first radial direction line.
        | StartAngle of float
        /// RadarChart: The angle of last point in the circle which should be startAngle - 360 or startAngle + 360. We'll calculate the direction of chart by 'startAngle' and 'endAngle'.
        | EndAngle of float
        /// RadarChart: The inner radius of first circle grid. If set a percentage, the final value is obtained by multiplying the percentage of maxRadius which is calculated by the width, height, cx, cy.
        | InnerRadius of obj
        /// RadarChart: The outer radius of last circle grid. If set a percentage, the final value is obtained by multiplying the percentage of maxRadius which is calculated by the width, height, cx, cy.
        | OuterRadius of obj

        // Events
        | OnClick of (React.MouseEvent -> unit)
        | OnMouseDown of (React.MouseEvent -> unit)
        | OnMouseUp of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseOver of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)
        static member inline Custom(key: string, value: obj): Chart = !!(key, value)

    type [<RequireQualifiedAccess>] Cartesian =
        /// The interpolation type of line. And customized interpolation function can be set to type. It's the same as type in Area.
        | Type of Interpolation
        /// The key of a group of data which should be unique in a LineChart.
        | DataKey of obj
        // The id of x-axis which is corresponding to the data.
        | XAxisId of obj
        // The id of y-axis which is corresponding to the data.
        | YAxisId of obj
        | LegendType of Legend
        /// If false set, labels will not be drawn. If true set, labels will be drawn which have the props calculated internally. If object set, labels will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom label element. If set a function, the function will be called to render customized label.
        | Label of obj
        /// The layout of line, usually inherited from parent.
        | Layout of Layout
        | Unit of string
        /// The name of data. This option will be used in tooltip and legend to represent a line. If no value was set to this option, the value of dataKey will be used alternatively.
        | Name of string
        /// If set false, animation of line will be disabled.
        | IsAnimationActive of bool
        /// Specifies when the animation should begin, the unit of this option is ms.
        | AnimationBegin of float
        /// Specifies the duration of animation, the unit of this option is ms.
        | AnimationDuration of float
        | AnimationEasing of Easing

        /// Line: If false set, dots will not be drawn. If true set, dots will be drawn which have the props calculated internally. If object set, dots will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom dot element.If set a function, the function will be called to render customized dot.
        | Dot of obj
        /// Line: The dot is shown when muser enter a line chart and this chart has tooltip. If false set, no active dot will not be drawn. If true set, active dot will be drawn which have the props calculated internally. If object set, active dot will be drawn which have the props mergered by the internal calculated props and the option. If ReactElement set, the option can be the custom active dot element.If set a function, the function will be called to render customized active dot.
        | ActiveDot of obj
        /// Line: The coordinates of all the points in the line, usually calculated internally.
        | Points of CoordinatePoint[]
        /// Line: Whether to connect a graph line across null points.
        | ConnectNulls of bool

        /// Bar: The width or height of each bar. If the barSize is not specified, the size of bar will be caculated by the barCategoryGap, barGap and the quantity of bar groups.
        | BarSize of float
        /// Bar: The maximum width of bar in a horizontal BarChart, or maximum height in a vertical BarChart.
        | MaxBarSize of float
        /// Bar: The minimal height of a bar in a horizontal BarChart, or the minimal width of a bar in a vertical BarChart. By default, 0 values are not shown. To visualize a 0 (or close to zero) point, set the minimal point size to a pixel value like 3. In stacked bar charts, minPointSize might not be respected for tightly packed values. So we strongly recommend not using this props in stacked BarChart.
        | MinPointSize of float
        /// Bar: If set a ReactElement, the shape of bar can be customized. If set a function, the function will be called to render customized shape.
        | Shape of React.ReactElement
        /// Bar: The stack id of bar, when two bars have the same value axis and same stackId, then the two bars are stacked in order.
        | StackId of obj

        // Events
        | OnClick of (React.MouseEvent -> unit)
        | OnMouseDown of (React.MouseEvent -> unit)
        | OnMouseUp of (React.MouseEvent -> unit)
        | OnMouseOver of (React.MouseEvent -> unit)
        | OnMouseOut of (React.MouseEvent -> unit)
        | OnMouseEnter of (React.MouseEvent -> unit)
        | OnMouseMove of (React.MouseEvent -> unit)
        | OnMouseLeave of (React.MouseEvent -> unit)
        interface Fable.Helpers.React.Props.IProp
        static member inline Custom(key: string, value: obj): Chart = !!(key, value)


type RechartComponent =
    interface end

module Imports =
    // Charts
    let lineChartEl: obj = import "LineChart" "recharts"
    let barChartEl: obj = import "BarChart" "recharts"
    let areaChartEl: obj = import "AreaChart" "recharts"
    let composedChartEl: obj = import "ComposedChart" "recharts"
    let pieChartEl: obj = import "PieChart" "recharts"
    let radarChartEl: obj = import "RadarChart" "recharts"
    let radialBarChartEl: obj = import "RadialBarChart" "recharts"
    let scatterChartEl: obj = import "ScatterChart" "recharts"

    // General Components
    let tooltipEl: obj = import "Tooltip" "recharts"
    let legendEl: obj = import "Legend" "recharts"

    // Cartesian Components
    let lineEl: obj = import "Line" "recharts"
    let barEl: obj = import "Bar" "recharts"
    let cartesianGridEl: obj = import "CartesianGrid" "recharts"
    let xaxisEl: obj = import "XAxis" "recharts"
    let yaxisEl: obj = import "YAxis" "recharts"

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Props
open Imports

let inline lineChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(lineChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline barChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(barChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline areaChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(areaChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline composedChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(composedChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline pieChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(pieChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline radarChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(radarChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline radialBarChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(radialBarChartEl, keyValueList CaseRules.LowerFirst props, children)

let inline scatterChart (props: Chart list) (children: RechartComponent list): React.ReactElement =
    createElement(scatterChartEl, keyValueList CaseRules.LowerFirst props, children)

// TODO: Tooltip props
let inline tooltip (props: obj list): RechartComponent =
    createElement(tooltipEl, keyValueList CaseRules.LowerFirst props, [])

// TODO: Legend props
let inline legend (props: obj list): RechartComponent =
    createElement(legendEl, keyValueList CaseRules.LowerFirst props, [])

let inline bar (props: IProp list): RechartComponent =
    createElement(barEl, keyValueList CaseRules.LowerFirst props, [])

let inline line (props: IProp list): RechartComponent =
    createElement(lineEl, keyValueList CaseRules.LowerFirst props, [])

let inline cartesianGrid (props: IProp list): RechartComponent =
    createElement(cartesianGridEl, keyValueList CaseRules.LowerFirst props, [])

let inline xaxis (props: IProp list): RechartComponent =
    createElement(xaxisEl, keyValueList CaseRules.LowerFirst props, [])

let inline yaxis (props: IProp list): RechartComponent =
    createElement(yaxisEl, keyValueList CaseRules.LowerFirst props, [])
