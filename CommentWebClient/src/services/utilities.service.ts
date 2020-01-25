export function forEachObj(obj: any, fn: (k: any, v: any) => void) {
    for (const key in obj) {
        if (obj.hasOwnProperty(key)) {
            const value = obj[key];
            invoke(fn, key, value);
        }
    }
}

export function invoke(fn: Function, ...args) {
    if (fn) fn(...args);
}

export function removeNullUndefinedProperty(o) {
    const _o = {}
    for (const k in o) {
        if (o.hasOwnProperty(k)) {
            const v = o[k];
            if (Array.isArray(v)) {
                const arr = v.map(x => {
                    return removeNullUndefinedProperty(x);
                });
                _o[k] = arr;
            }
            else {
                if(v) {
                    _o[k] = v;
                }
            }
        }
    }
    return _o;
}