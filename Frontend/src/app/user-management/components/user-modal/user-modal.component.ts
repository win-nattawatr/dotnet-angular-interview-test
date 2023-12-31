import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EditableUserData, User } from '../../models/user.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserManagementService } from '../../services/user-management.service';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrl: './user-modal.component.css',
})
export class UserModalComponent implements OnInit {
  @Input() user?: User;

  userFormGroup: FormGroup;

  constructor(
    private _userManagementService: UserManagementService,
    private _activeModal: NgbActiveModal
  ) {
    this.userFormGroup = new FormGroup({
      firstname: new FormControl(null, Validators.required),
      lastname: new FormControl(null, Validators.required),
      phoneNumber: new FormControl(null, [
        Validators.required,
        Validators.pattern('^[0-9]+$'),
      ]),
      email: new FormControl(null, [Validators.required, Validators.email]),
    });
  }

  ngOnInit(): void {
    if (this.user) {
      this.userFormGroup.patchValue(this.user);
    }
  }

  dismiss(payload?: any): void {
    payload ? this._activeModal.dismiss(payload) : this._activeModal.dismiss();
  }

  close(payload?: any): void {
    payload ? this._activeModal.close(payload) : this._activeModal.close();
  }

  hasError(formControlName: string): boolean {
    const formControl = this.userFormGroup.get(formControlName);
    if (formControl) {
      return formControl.touched || formControl.dirty
        ? formControl.invalid
        : false;
    }
    return false;
  }

  submit() {
    this.userFormGroup.markAllAsTouched();
    if (this.userFormGroup.valid) {
      const data = this.userFormGroup.value as EditableUserData;

      try {
        const onSubmit$ =
          this.user && this.user.hn
            ? this._userManagementService.updateUser(this.user.hn, data)
            : this._userManagementService.addUser(data);

        const onSubmitSubscription = onSubmit$.subscribe({
          next: (response) => {
            console.log(response);
            this.close();
            onSubmitSubscription.unsubscribe();
          },
        });
      } catch (e) {
        console.error(e);
      }
    }
  }
}
