import { NgModule } from '@angular/core';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button'
import { MatTableModule } from'@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';


@NgModule({
    imports: [
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatToolbarModule,
        MatSelectModule,
        MatCardModule

    ],
    exports:[
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatTableModule,
        MatSortModule,
        MatPaginatorModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatToolbarModule,
        MatSelectModule,
        MatCardModule
    ]
})
export class MaterialModule {}




// import { NgModule } from '@angular/core';

// import { MatNativeDateModule } from '@angular/material/core';
// import { MatSidenavModule } from '@angular/material/sidenav';
// import { MatToolbarModule } from '@angular/material/toolbar';
// import { MatListModule } from '@angular/material/list';
// import { MatTabsModule } from '@angular/material/tabs'; 
// import { MatCardModule } from '@angular/material/card'; 
// import { MatSelectModule } from '@angular/material/select'; 
// import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
// import { MatDialogModule } from '@angular/material/dialog';
// import { MatTableModule } from'@angular/material/table';
// import { MatSortModule } from '@angular/material/sort';
// import { MatPaginatorModule } from '@angular/material/paginator';




// @NgModule({
//     imports:[
//         
//         MatIconModule,
//        
//         MatInputModule,
//         MatDatepickerModule,
//         MatNativeDateModule,
//         MatSidenavModule, 
//         MatToolbarModule,
//         MatListModule,
//         MatTabsModule,
//         MatCardModule,
//         MatSelectModule,
//         MatProgressSpinnerModule,
//         MatDialogModule,
//         MatTableModule,
//         MatSortModule,
//         MatPaginatorModule
//     ],
//     exports:[
//        
//         MatIconModule,
//        
//         MatDatepickerModule,
//         MatNativeDateModule,
//         MatSidenavModule,
//         MatToolbarModule,
//         MatListModule,
//         MatTabsModule,
//         MatCardModule,
//         MatSelectModule,
//         MatProgressSpinnerModule,
//         MatDialogModule,
//         MatTableModule,
//         MatSortModule,
//         MatPaginatorModule
        
//     ]
// })
// export class MaterialModule {}