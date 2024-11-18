<<<<<<< HEAD
//import { Color } from '@kurkle/color';
export declare function isPatternOrGradient(value: unknown): value is CanvasPattern | CanvasGradient;
export declare function color(value: CanvasGradient): CanvasGradient;
export declare function color(value: CanvasPattern): CanvasPattern;
//export declare function color(value: string | {
//    r: number;
//    g: number;
//    b: number;
//    a: number;
//} | [number, number, number] | [number, number, number, number]): Color;
//export declare function getHoverColor(value: CanvasGradient): CanvasGradient;
//export declare function getHoverColor(value: CanvasPattern): CanvasPattern;
//export declare function getHoverColor(value: string): string;
=======
import { Color } from '@kurkle/color';
export declare function isPatternOrGradient(value: unknown): value is CanvasPattern | CanvasGradient;
export declare function color(value: CanvasGradient): CanvasGradient;
export declare function color(value: CanvasPattern): CanvasPattern;
export declare function color(value: string | {
    r: number;
    g: number;
    b: number;
    a: number;
} | [number, number, number] | [number, number, number, number]): Color;
export declare function getHoverColor(value: CanvasGradient): CanvasGradient;
export declare function getHoverColor(value: CanvasPattern): CanvasPattern;
export declare function getHoverColor(value: string): string;
>>>>>>> b6cef1a2f35980402036641f65579444d10644ff
