import { Directive, Input } from "@angular/core";
import { AbstractControl, NG_VALIDATORS, Validator } from "@angular/forms";
import { domain } from "process";

@Directive({
  selector: '[appSelectValidator]',
  providers:[{
    provide: NG_VALIDATORS,
    useExisting: SelectRequiredValidatorDirective,
    multi: true
  }]
})
export class SelectRequiredValidatorDirective implements Validator {
  @Input() appSelectValidator: string;
  // validate(control: AbstractControl): { [key: string]: any } | null {
  //   return control.value === this.appSelectValidator  ? { 'defaultSelected': true } : null;
  // }

  validate(control: AbstractControl) {
    let value;
    let branch = control.value;
    if(branch != null) {
       value = branch.toString();
    }
    if(branch === this.appSelectValidator || branch === null || branch === "null" || value === this.appSelectValidator){
      return {branchDomain: {parsedDomain: domain}}
    }
    return null;
  }
}
