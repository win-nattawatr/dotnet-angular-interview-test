import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementRoutingModule } from './user-management-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserManagementService } from './services/user-management.service';

@NgModule({
  declarations: [],
  providers: [UserManagementService],
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
})
export class UserManagementModule {}
