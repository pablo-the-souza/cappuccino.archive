import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ArchiveComponent } from './archive/archive.component';
import { ArchiveFileComponent } from './archive/archive-file/archive-file.component';
import { ArchiveFileFormComponent } from './archive/archive-file/archive-file-form/archive-file-form.component';
import { ArchiveFileListComponent } from './archive/archive-file/archive-file-list/archive-file-list.component';
import { ArchiveBoxComponent } from './archive/archive-box/archive-box.component';
import { ArchiveBoxFormComponent } from './archive/archive-box/archive-box-form/archive-box-form.component';
import { ArchiveBoxListComponent } from './archive/archive-box/archive-box-list/archive-box-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ArchiveComponent,
    ArchiveFileComponent,
    ArchiveFileFormComponent, 
    ArchiveFileListComponent,
    ArchiveBoxComponent,
    ArchiveBoxFormComponent,
    ArchiveBoxListComponent
    

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FlexLayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
