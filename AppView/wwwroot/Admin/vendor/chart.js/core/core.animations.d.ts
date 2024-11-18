export default class Animations {
    constructor(chart: any, config: any);
    _chart: any;
<<<<<<< HEAD
    //_properties: Map<any, any>;
=======
    _properties: Map<any, any>;
>>>>>>> b6cef1a2f35980402036641f65579444d10644ff
    configure(config: any): void;
    /**
       * Utility to handle animation of `options`.
       * @private
       */
    private _animateOptions;
    /**
       * @private
       */
    private _createAnimations;
    /**
       * Update `target` properties to new values, using configured animations
       * @param {object} target - object to update
       * @param {object} values - new target properties
       * @returns {boolean|undefined} - `true` if animations were started
       **/
    update(target: object, values: object): boolean | undefined;
}
