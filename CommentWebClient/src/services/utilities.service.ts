import { HttpEventType, HttpResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

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

export function clean(o) {
    const _o = {}
    for (const k in o) {
        if (o.hasOwnProperty(k)) {
            const v = o[k];
            if (Array.isArray(v)) {
                const arr = v.map(x => {
                    return clean(x);
                });
                _o[k] = arr;
            }
            else {
                if (v) {
                    _o[k] = v;
                }
            }
        }
    }
    return _o;
}

export function getLang() {
    const lang = localStorage.getItem('app_lang');
    return lang || 'en';
}

export function createAnchorAndFireForDownload(blob: Blob, fileName?: string) {
    const _event = document.createEvent('MouseEvent');
    _event.initEvent('click', false, false);
    const href = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.download = fileName;
    a.href = href;
    document.body.appendChild(a);
    a.dispatchEvent(_event);
    URL.revokeObjectURL(href);
    document.body.removeChild(a);
}

export function progress(event: any, progress, success) {
    if (event.type === HttpEventType.UploadProgress) {
        if (progress) {
            progress(Math.round(100 * event.loaded / event.total));
        }
    } else if (event instanceof HttpResponse) {
        if (success) {
            success(event.body);
        }
    } else if (event.type === HttpEventType.DownloadProgress) {
        if (progress) {
            progress(event.loaded);
        }
    }
}

export function buildUrl(url: string, ...args) {
    const _args = args.filter(x => x);
    const _url = `${url}?${_args.join('&')}`;
    return _url;
}

export function toBengali(obj, t: TranslateService) {
    for (const key in obj) {
        if (obj.hasOwnProperty(key)) {
            if (!Array.isArray(obj[key])) {
                convertPropertyToBengali(obj, key, t);
            }
            else {
                for (let i = 0; i < obj[key].length; i++) {
                    toBengali(obj[key][i], t);
                }
            }
        }
    }
    return obj;
}

export function ignoreKeys() {
    return [
        "id", "offset", "limit", "eBook", "categoryId"
    ];

}

export function convertPropertyToBengali(obj, key, t: TranslateService) {
    if (!ignoreKeys().includes(key)) {
        if (typeof (obj[key]) == "number" || /^\d+$/.test(obj[key])) {
            const v = convertValueToBengali(obj[key].toString());
            obj[key] = v;
        }
        else if (typeof (obj[key]) == "string") {
            if (key && obj[key]) {
                obj[key] = t.instant(obj[key]);
            }
        }
        else if (typeof (obj[key]) == "object") {
            toBengali(obj[key], t)
        }
    }
}

export function convertValueToBengali(value: any) {
    value = value.toString();
    const map = getNumberMap();
    const len = value.length;
    let bengaliNumber = ""
    for (let i = 0; i < len; i++) {
        const l = map[value[i]];
        if (l) {
            bengaliNumber += l;
        }
        else {
            bengaliNumber += value[i];
        }
    }
    return bengaliNumber;
}

export function convertValueToEnglish(value: any) {
    value = value.toString();
    const map = getNumberMap();
    const len = value.length;
    let EnglishNumber = "";
    for (let i = 0; i < len; i++) {
        const l = getKeyByValue(map, value[i]);
        if (l) {
            EnglishNumber += l;
        }
        else {
            EnglishNumber += value[i];
        }
    }
    return EnglishNumber;
}

export function getKeyByValue(object, value) {
    return Object.keys(object).find(key => object[key] === value);
}

export function getNumberMap() {
    return {
        '0': '০',
        '1': '১',
        '2': '২',
        '3': '৩',
        '4': '৪',
        '5': '৫',
        '6': '৬',
        '7': '৭',
        '8': '৮',
        '9': '৯'
    }
}

export function clone(obj: any): any {
    if (obj) {
        return JSON.parse(JSON.stringify(obj));
    }
    return obj;
}

export function beep(vol = 90, freq = 500, duration = 150) {
    var a = new AudioContext()
    var v = a.createOscillator()
    var u = a.createGain()
    v.connect(u)
    v.frequency.value = freq
    v.type = "square"
    u.connect(a.destination)
    u.gain.value = vol * 0.01
    v.start(a.currentTime)
    v.stop(a.currentTime + duration * 0.001)
}

export function buildFilter(fieldName, operator, value) {
    if (value) {
        return `Filter=${fieldName} ${operator} ${value}`;
    }
    return "";
}