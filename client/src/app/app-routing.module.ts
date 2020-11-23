import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ArchiveBoxComponent } from './archive/archive-box/archive-box.component';
import { ArchiveFileComponent } from './archive/archive-file/archive-file.component';


const routes: Routes = [
    { path: '', component: ArchiveFileComponent },
    { path: 'boxes', component: ArchiveBoxComponent },

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule], 
    providers: []
})
export class AppRoutingModule {}