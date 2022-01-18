import { TestBed } from '@angular/core/testing';

import { DevLogsService } from './dev-logs.service';

describe('DevLogsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DevLogsService = TestBed.get(DevLogsService);
    expect(service).toBeTruthy();
  });
});
