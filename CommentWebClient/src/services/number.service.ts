import { Injectable } from "@angular/core";
import { getLang } from "./utilities.service";

@Injectable()
export class NumberService {

    private bnNumbers = {
        '1': '১',
        '2': '২',
        '3': '৩',
        '4': '৪',
        '5': '৫',
        '6': '৬',
        '7': '৭',
        '8': '৮',
        '9': '৯',
        '0': '০'
    };

    convert(number: string): string {
        const lang = getLang();
        const converted = [];
        if (number.length && lang == 'bn') {
            for (let i = 0; i < number.length; i++) {
                const ch = number[i];
                converted.push(this.bnNumbers[ch])
            }
            if (converted.length) {
                return converted.join();
            }
        }
        return number;
    }

}