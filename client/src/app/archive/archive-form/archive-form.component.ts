import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { ArchiveService } from '../archive.service';

@Component({
  selector: 'app-archive-form',
  templateUrl: './archive-form.component.html',
  styleUrls: ['./archive-form.component.css']
})
export class ArchiveFormComponent implements OnInit {
  update: string;
  selectedOption: string; 
  boxes: Observable<any>; 
  files : Observable<any>; 
  isAddingBox: boolean; 

  constructor(public service: ArchiveService) { }

  ngOnInit(): void {
    this.isAddingBox = false; 
    this.resetForm();
    this.files = this.service.getFilesForForm();
    this.boxes = this.service.getBoxes();

    this.service.boxFormData = {
      id: "",
      name: "",
      code: ""
    }
  }



  onSubmit(form: NgForm) {
    console.log(form.value)
    if (this.service.fileFormData.id == "")
      this.insertFile(form)
    else 
      this.updateFile(form)
  }

  insertFile(form: NgForm) {
    console.log("I'm boxID = " + form.value.BoxId)
    this.service.postFile().subscribe(
      res => {
        this.resetForm(form);
        this.service.getFiles();
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();

    this.service.fileFormData = {
      id: "",
      name: "",
      code: "",
      value: 0,
      boxId: "" , 
      
    }
  }


  updateBox(event: any) {
    this.service.fileFormData.boxId = this.selectedOption;
  }

  updateFile(form: NgForm) {
    this.service.putFileDetail().subscribe(
      res => {
        console.log("Update ok")
        this.resetForm(form);
        this.service.getFiles();
      },
      err => {
        console.log(err);
        
      }
    );
  }

  changeIsAddingBox(){
    this.isAddingBox = true; 
  }

  insertBox(boxForm: NgForm){
    this.isAddingBox = false; 
    this.service.postBox().subscribe(
      res => {
        console.log("Box Inserted")
        this.boxes = this.service.getBoxes();
      },
      err => {
        console.log(err);
      }
    );
  }


}
