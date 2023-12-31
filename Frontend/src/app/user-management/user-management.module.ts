import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementRoutingModule } from './user-management-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserManagementService } from './services/user-management.service';
import {
  NgbModalModule,
  NgbPaginationModule,
} from '@ng-bootstrap/ng-bootstrap';
import { UserManagementPageComponent } from './pages/user-management-page/user-management-page.component';
import { UserModalComponent } from './components/user-modal/user-modal.component';

@NgModule({
  declarations: [UserManagementPageComponent, UserModalComponent],
  providers: [UserManagementService],
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbPaginationModule,
    NgbModalModule,
  ],
})
export class UserManagementModule {}
