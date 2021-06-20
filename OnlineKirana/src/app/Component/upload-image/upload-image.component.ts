import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UploadImageService } from '../../Services/upload-image.service';
@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css'],
  providers:[UploadImageService]
})
export class UploadImageComponent implements OnInit {
  profileForm: FormGroup;
  error: string;

  fileUpload = {status: '', message: '', filePath: ''};

  constructor(private fb: FormBuilder,private UploadImageService : UploadImageService) { }


  ngOnInit() {
    this.profileForm = this.fb.group({
      name: [''],
      profile: ['']
    });
  }

  onSelectedFile(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.profileForm.get('profile').setValue(file);
    }
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('name', this.profileForm.get('name').value);
    formData.append('profile', this.profileForm.get('profile').value);
    console.log("hi");

    this.UploadImageService.upload(formData).subscribe(
      res => this.fileUpload = res,
      err => this.error = err
      
    );
    console.log("no");
  }

}
