import { ControlComponent } from "src/app/shared/control.component";
import { CheckboxConfig, ControlConfig, ControlType, InputConfig } from "src/app/shared/form-page/control.config";
import { SelectControlComponent } from "src/app/shared/select-control/select-control.component";
import { text } from "src/constants/text";
import { ValidatorService } from "./validator.service";

export class Control {

    static namex(): InputConfig {
        return <InputConfig>Control.control(ControlType.Input, text.name, text.name, true);
    }

    static description(mandatory?: boolean): InputConfig {
        return <InputConfig>Control.control(ControlType.Text, text.description, text.description, mandatory);
    }

    static input(name: string, label?: string, mandatory?: boolean): InputConfig {
        return <InputConfig>Control.control(ControlType.Input, name, label, mandatory);
    }

    static email(name: string, label?: string, mandatory?: boolean): InputConfig {
        const config = <InputConfig>Control.control(ControlType.Input, name, label, mandatory);
        config.type = 'email';
        return config;
    }

    static number(name: string, label?: string, mandatory?: boolean): InputConfig {
        const config = <InputConfig>Control.control(ControlType.Input, name, label, mandatory);
        config.type = 'number';
        return config;
    }

    static checkbox(name: string, label?: string, tooltip?: string, mandatory?: boolean): CheckboxConfig {
        const config = <CheckboxConfig>Control.control(ControlType.Checkbox, name, label, mandatory);
        config.tooltip = tooltip;
        return config;
    }

    static text(name: string, label?: string, mandatory?: boolean): ControlConfig {
        return Control.control(ControlType.Text, name, label, mandatory);
    }

    static select(name: string, label?: string, mandatory?: boolean, controlAccessor?: (control: SelectControlComponent) => void): ControlConfig {
        return Control.control(ControlType.SingleSelect, name, label, mandatory, controlAccessor);
    }

    static control(type: ControlType, name: string, label?: string, mandatory?: boolean, controlAccessor?: (control: ControlComponent) => void): ControlConfig {
        return {
            name: name,
            label: label || name,
            controlType: type,
            placeholder: label,
            buildOptions: (validator: ValidatorService) => {
                return mandatory ? [null, [], [
                    validator.required()
                ]] : [];
            },
            controlAccessor: controlAccessor
        }
    }
}