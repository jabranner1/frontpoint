import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IndividualForm } from '../models/individual-form';
import { Injectable } from '@angular/core';

@Injectable()
export class IndividualFormFactory {
  /**
   * builds FormGorup and applies validators
   * @returns
   */
  create(): IndividualForm {
    const form = this.buildForm();
    this.addValidators(form);
    return form;
  }

  private buildForm(): IndividualForm {
    return new FormGroup({
      id: new FormControl(),
      prefix: new FormControl(),
      firstName: new FormControl(),
      middleName: new FormControl(),
      lastName: new FormControl(),
      dateOfBirth: new FormControl(),
      telephoneNumber: new FormControl(),
      addressLine1: new FormControl(),
      addressLine2: new FormControl(),
      city: new FormControl(),
      state: new FormControl(),
      zip: new FormControl(),
      country: new FormControl(),
    }) as IndividualForm;
  }

  private addValidators(form: IndividualForm) {
    form.controls.firstName?.addValidators([Validators.required]);
    form.controls.lastName?.addValidators([Validators.required]);
    form.controls.dateOfBirth?.addValidators([Validators.required]);
    form.controls.telephoneNumber?.addValidators([Validators.required]);
    form.controls.addressLine1?.addValidators([Validators.required]);
    form.controls.city?.addValidators([Validators.required]);
    form.controls.state?.addValidators([Validators.required]);
    form.controls.zip?.addValidators([Validators.required]);
    form.controls.country?.addValidators([Validators.required]);
  }
}
