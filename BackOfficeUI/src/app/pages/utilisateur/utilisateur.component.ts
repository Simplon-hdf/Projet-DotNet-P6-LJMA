import { AfterViewInit, Component, OnInit, inject, model, viewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { User, UtilisateurService } from './utilisateur.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-utilisateur',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    ReactiveFormsModule,
  ],
  templateUrl: './utilisateur.component.html',
  styleUrls: ['./utilisateur.component.css'],
})
export class UtilisateurComponent implements AfterViewInit, OnInit {
  private formBuilder = inject(FormBuilder);
  private utilisateurService = inject(UtilisateurService);
  displayedColumns: string[] = [
    // 'id',
    'prenom',
    'nom',
    'telephone',
    'email',
    'role',
  ];
  dataSource: MatTableDataSource<User> = new MatTableDataSource<User>();
  isEditUserModal: boolean = false;
  userEdited = model<User>();
  userFormGroup = this.formBuilder.group({
    id: ['', Validators.required],
    nom: ['', Validators.required],
    prenom: ['', Validators.required],
    telephone: ['', Validators.required],
    email: ['', Validators.required],
    role: ['', Validators.required],
  });

  paginator = viewChild(MatPaginator);
  sort = viewChild(MatSort);

  constructor() {}
  ngOnInit(): void {
    this.utilisateurService.getUsers().subscribe({
      next: (result: User[]) => (this.dataSource.data = result),
      error: (error) => {},
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator()!;
    this.dataSource.sort = this.sort()!;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  onRowClicked(row: User) {
    this.openUserEdit(row);
  }

  //#region
  openUserEdit(user: User): void {
    this.userEdited.set(user);
    this.userFormGroup.patchValue(user);
    this.isEditUserModal = true;
  }

  closeUserEdit(): void {
    this.userEdited.set(undefined);
    this.isEditUserModal = false;
  }

  saveUserEdit(): void {
    if (this.userFormGroup.valid) {
      const updatedUser = this.userFormGroup.value as User;
      this.utilisateurService.putUser(updatedUser).subscribe({
        next: () => {
          // Update the dataSource with the edited user
          const index = this.dataSource.data.findIndex(
            (u) => u.id === updatedUser.id
          );
          if (index !== -1) {
            this.dataSource.data[index] = updatedUser;
            this.dataSource._updateChangeSubscription(); // Notify the table of the data change
          }
          this.closeUserEdit();
        },
        error: (error) => console.error('Error updating user:', error),
      });
    }
  }

  deleteUser(id: string | undefined) {
    if (id) {
      this.utilisateurService.deleteUser(id).subscribe({
        next: () => {
          // Remove the user from the dataSource
          this.dataSource.data = this.dataSource.data.filter(user => user.id !== id);
          this.dataSource._updateChangeSubscription(); // Notify the table of the data change
          this.closeUserEdit();
          // console.log('User deleted successfully');
          // Optionally, you can add a notification or alert here to inform the user
        },
        error: (error) => {
          console.error('Error deleting user:', error);
          // Optionally, you can add an error notification here
        }
      });
    } else {
      console.error('Cannot delete user: ID is undefined');
      // Optionally, you can add an error notification here
    }
  }
  
  //#endregion
}
